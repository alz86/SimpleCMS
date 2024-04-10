var l = abp.localization.getResource('SimpleCMS');
var simpleCMSAppService = decisionTree.plugins.simpleCMS.controllers.contentEntry;

$(function () {

    _dataTable = $('#EntriesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            order: [[1, 'asc']],
            processing: true,
            serverSide: true,
            scrollX: true,
            paging: true,
            searching: false,
            ajax: abp.libs.datatables.createAjax(
                simpleCMSAppService.getAllPaged
            ),
            columnDefs: [
                {
                    title: l('SimpleCMS:Pages:Actions'),
                    rowAction: {
                        items: [
                            {
                                text: l('SimpleCMS:Pages:Edit'),
                                action: function (data) {
                                    var _editModal = new abp.ModalManager({
                                        viewUrl: abp.appPath + 'SimpleCMS/AddEditEntry',
                                    });
                                    _editModal.open({ id: data.record.id })
                                }
                            }
                        ]
                    }
                },
                {
                    title: l('SimpleCMS:Fields:Name'),
                    data: "name"
                },
                {
                    title: l('SimpleCMS:Fields:Title'),
                    data: "title"
                }
            ]
        })
    );

    $('#NewEntryButton').click(function (e) {
        e.preventDefault();
        var _createModal = new abp.ModalManager({
            viewUrl: abp.appPath + 'SimpleCMS/AddEditEntry',
        });
        _createModal.open();
    });
});