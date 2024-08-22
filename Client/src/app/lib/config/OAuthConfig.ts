import { AuthConfig } from 'angular-oauth2-oidc';
import { appConfig } from './AppConfig';

  export const authCodeFlowConfig: AuthConfig = {
    issuer              : appConfig.issuer,
    tokenEndpoint       : `${appConfig.issuer}/connect/token`,
    clientId            : appConfig.clientId,
    showDebugInformation: true,
    requestAccessToken  : true,
    responseType        : 'token',
    oidc                : false,
    requireHttps        : false,
    scope               : ''
  };