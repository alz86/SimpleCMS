var l = abp.localization.getResource('SimpleCMS');
var simpleCMSAppService = decisionTree.plugins.simpleCMS.controllers.contentEntry;

$(function () {

    //Modal init code
    abp.modals.AddEditEntry = function () {
        function initModal(modalManager, args) {

            var $form = modalManager.getForm();
            var $postTextInput = $form.find("input[name='ContentEntryInfo.Content']");

            var newPostEditor = new toastui.Editor({
                el: $form.find('.new-entry-editor')[0],
                usageStatistics: false,
                initialEditType: 'wysiwyg',
                height: 'auto',
                initialValue: $postTextInput.val(),
                hideModeSwitch: true,
            });

            newPostEditor.on('blur', function () {
                var postText = newPostEditor.getHTML();
                $postTextInput.val(postText);
            });
        };

        return {
            initModal: initModal
        };
    };

    //modal
    var createEditModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'SimpleCMS/AddEditEntry',
        modalClass: 'AddEditEntry'
    });

    //datable
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
                                    createEditModal.open({ id: data.record.id })
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

    createEditModal.onResult(function () {
        _dataTable.ajax.reloadEx();
    });

    $('#NewEntryButton').click(function (e) {
        e.preventDefault();
        createEditModal.open();
    });
});