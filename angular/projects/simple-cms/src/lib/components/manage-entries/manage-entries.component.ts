import { Component, OnDestroy, OnInit } from '@angular/core';
import { CoreModule, ListService, LocalizationService, RoutesService } from '@abp/ng.core';
import { ContentEntryDto } from '@proxy/dto';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ThemeSharedModule, ToasterService } from '@abp/ng.theme.shared';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EntriesService } from '../../services/entries/entries.service';
import { Subscription } from 'rxjs';
import { Editor, NgxEditorModule, Toolbar } from 'ngx-editor';
import { ngxEditorRequiredValidator } from '../ngx-editor-required-validator';

@Component({
  selector: 'lib-manage-entries',
  standalone: true,
  imports: [ThemeSharedModule, CommonModule, CoreModule, NgxEditorModule],
  templateUrl: './manage-entries.component.html',
  styleUrl: './manage-entries.component.css',
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class ManageEntriesComponent implements OnInit, OnDestroy {
  public entries: ContentEntryDto[];
  public isModalOpen: boolean = false;
  public isModalBusy: boolean = false;
  public form: FormGroup;
  public editingContent: ContentEntryDto;
  private entriesSubscription: Subscription;

  private editingId?: string = null;
  editor: Editor;
  html = '';
  public toolbar: Toolbar = [
    ['bold', 'italic'],
    ['underline', 'strike'],
    ['code', 'blockquote'],
    ['ordered_list', 'bullet_list'],
    [{ heading: ['h1', 'h2', 'h3', 'h4', 'h5', 'h6'] }],
    ['link', 'image'],
    ['text_color', 'background_color'],
    ['align_left', 'align_center', 'align_right', 'align_justify'],
  ];

  constructor(
    private readonly entriesService: EntriesService,
    public readonly list: ListService,
    private readonly fb: FormBuilder,
    private readonly toaster: ToasterService,
    private readonly localizationService: LocalizationService,
    private readonly routesService: RoutesService
  ) {}

  ngOnInit(): void {
    this.editor = new Editor({
      attributes: {
        style: 'height: 300px; overflow: auto;',
      },
    });
    this.entriesSubscription = this.entriesService.entries$.subscribe(entries => {
      this.entries = entries;
    });
  }

  ngOnDestroy(): void {
    this.editor.destroy();
    this.entriesSubscription.unsubscribe();
  }

  buildForm() {
    this.form = this.fb.group({
      title: [this.editingContent.title || null, Validators.required],
      name: [this.editingContent.name || null, Validators.required],
      content: [this.editingContent.content || null, ngxEditorRequiredValidator()],
    });
  }

  createNew() {
    this.editingId = null;
    this.showModal({} as ContentEntryDto);
  }

  edit(id: string) {
    this.editingId = id;
    this.entriesService.getCompleteEntry(id).subscribe(entry => this.showModal(entry));
  }

  private showModal(content: ContentEntryDto) {
    this.editingContent = content;
    this.buildForm();
    this.isModalOpen = true;
  }

  public save() {
    if (this.form.invalid) {
      return;
    }

    this.isModalBusy = true;

    this.entriesService.saveEntry(this.editingId, this.form.value).subscribe(
      s => {
        //success message
        var isCreation = this.editingId === null;
        this.toaster.success(
          this.localizationService.instant(
            `SimpleCMS::Pages:Manage:${isCreation ? 'Create' : 'Edit'}:Success`
          ),
          this.localizationService.instant('SimpleCMS::Pages:Manage:OperationCompleted')
        );

        this.editingId = null;
        this.isModalOpen = false;
        this.form.reset();
      },
      null,
      () => (this.isModalBusy = false)
    );
  }
}
