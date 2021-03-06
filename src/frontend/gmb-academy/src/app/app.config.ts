import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAppConfig } from './app-config';
import { config } from 'rxjs';

@Injectable()
export class AppConfig {
  settings: IAppConfig;
  constructor(private http: HttpClient) { }

  get urls() {
    return this.settings.webApiUrls;
  }

  private interpolateSettings(res: IAppConfig) {
    const cloneObj = { ...res };
    const cloneUrl = cloneObj.webApiUrls;
    for (const prop in cloneUrl) {
      if ((<any>cloneUrl).hasOwnProperty(prop) && prop !== 'BaseUrl') {
        cloneUrl[prop] = cloneUrl.BaseUrl + cloneUrl[prop];
      }
    }
    cloneObj.webApiUrls = cloneUrl;
    return cloneObj;
  }

  load() {
    const jsonFile = `assets/config.json`;
    return new Promise<void>((resolve, reject) => {
      this.http.get(jsonFile).toPromise()
      .then(
        (response: IAppConfig) => {
          const resp = <IAppConfig>response;
          this.settings = this.interpolateSettings(resp);
          resolve();
      })
      .catch(
        (response: any) => {
        reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
      });
    });
  }
}
