import type { AxiosInstance } from 'axios';
import { AsyncRunnerMethod } from './api.types';
import { inject, injectable } from 'inversify';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

@injectable()
export default abstract class ApiClientBase {
  protected api: AxiosInstance;

  constructor(@inject(ServiceSymbols.AxiosInstance) api: AxiosInstance) {
    this.api = api;
  }

  protected readonly asyncRunner: AsyncRunnerMethod = async (promise) => {
    try {
      return await promise();
    } catch (ex) {
      console.log(ex);
      throw ex;
    }
  };

  protected readonly isSuccessfulStatusCode = (code: number): boolean => code >= 200 && code < 300;
}
