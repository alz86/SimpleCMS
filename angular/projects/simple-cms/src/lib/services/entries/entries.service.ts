import { Injectable } from '@angular/core';
import { ContentEntryService } from '@proxy/controllers';
import { ContentEntryDto, CreateUpdateContentEntryDto } from '@proxy/dto';
import { BehaviorSubject, Observable, defer, tap } from 'rxjs';

/**
 * @description Service which handles all the operations associated
 * to content entities, providing also a stream to the whole application
 * to be notified when the entries list changes.
 */
@Injectable({
  providedIn: 'root',
})
export class EntriesService {
  private readonly entriesSubject = new BehaviorSubject<ContentEntryDto[]>([]);
  public readonly entries$ = this.entriesSubject.asObservable();
  private init = false;

  constructor(private contentEntryService: ContentEntryService) {}

  /**
   * Ensures the service is initialized,
   * loading the entries from the server if needed.
   */
  public ensureInit() {
    if (!this.init) {
      this.loadEntries();
      this.init = true;
    }
  }

  private loadEntries(): void {
    this.contentEntryService.getAll().subscribe(entries => {
      this.entriesSubject.next(entries);
    });
  }

  /**
   * Gets the a whole content entry
   * (including the value of its 'content' property)
   * from the server
   * @param id Id of entry to load
   */
  getCompleteEntry(id: string) {
    return this.contentEntryService.getCMSContentByEntryId(id);
  }

  /**
   * Saves the content of the supplied entry, either
   * by creating or updating it.
   * @param id Id of the entry to save
   * @param entry Entry to save
   * @returns Entry
   */
  saveEntry(id: string, entry: CreateUpdateContentEntryDto) {
    return this.contentEntryService.insertOrUpdateCMSContentByIdAndEntryDto(id, entry).pipe(
      tap(newEntry => {
        //the new entry contains the whole content for the page. Since
        //the other entries doesn't, and to keep in consistent, we just remove
        //it, since its value is never used.
        newEntry.content = '';
        const currentEntries = this.entriesSubject.getValue();
        if (id) {
          const index = currentEntries.findIndex(e => e.id === id);
          currentEntries[index] = newEntry;
        } else {
          currentEntries.push(newEntry);
        }
        this.entriesSubject.next(currentEntries);
      })
    );
  }
}
