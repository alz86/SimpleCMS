import type { EntityDto } from '@abp/ng.core';

export interface ContentEntryDto extends EntityDto<string> {
  name?: string;
  title?: string;
  content?: string;
}

export interface CreateUpdateContentEntryDto extends EntityDto<string> {
  name: string;
  title: string;
  content: string;
}
