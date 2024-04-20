import { AxiosInstance } from 'axios';
import { AsyncRunnerMethod, Props } from './api.types';

export default abstract class ApiClientBase {
  protected onError: (error: unknown) => void;

  protected api: AxiosInstance;

  constructor(props: Props) {
    this.onError = props.onError;
    this.api = props.api;
  }

  protected readonly asyncRunner: AsyncRunnerMethod = async (promise) => {
    try {
      return await promise();
    } catch (ex) {
      this.onError(ex);
      throw ex;
    }
  };

  protected readonly isSuccessfulStatusCode = (code: number): boolean => code >= 200 && code < 300;
}
