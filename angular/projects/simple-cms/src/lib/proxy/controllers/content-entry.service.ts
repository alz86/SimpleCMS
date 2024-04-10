import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ContentEntryDto, CreateUpdateContentEntryDto } from '../dto/models';

@Injectable({
  providedIn: 'root',
})
export class ContentEntryService {
  apiName = 'Default';

  getAll = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ContentEntryDto[]>(
      {
        method: 'GET',
        url: '/api/simpleCMS/entry',
      },
      { apiName: this.apiName, ...config }
    );

  getCMSContentByEntryId = (entryId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ContentEntryDto>(
      {
        method: 'GET',
        url: `/api/simpleCMS/entry/${entryId}`,
      },
      { apiName: this.apiName, ...config }
    );

  insertOrUpdateCMSContentByIdAndEntryDto = (
    id: string,
    entryDto: CreateUpdateContentEntryDto,
    config?: Partial<Rest.Config>
  ) =>
    this.restService.request<any, ContentEntryDto>(
      {
        method: 'POST',
        url: `/api/simpleCMS/entry/${id || ''}`,
        body: entryDto,
      },
      { apiName: this.apiName, ...config }
    );

  constructor(private restService: RestService) {}
}
