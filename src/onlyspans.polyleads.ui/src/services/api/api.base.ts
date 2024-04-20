import { AxiosInstance } from 'axios';
import { AsyncRunnerMethod } from './api.types';

export default abstract class ApiClientBase {
  protected api: AxiosInstance;

  constructor(api: AxiosInstance) {
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
