import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'SimpleCMS',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44356/',
    redirectUri: baseUrl,
    clientId: 'SimpleCMS_App',
    responseType: 'code',
    scope: 'offline_access SimpleCMS',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44356',
      rootNamespace: 'DecisionTree.Plugins.SimpleCMS',
    },
    SimpleCMS: {
      url: 'https://localhost:44336',
      rootNamespace: 'DecisionTree.Plugins.SimpleCMS',
    },
  },
} as Environment;
