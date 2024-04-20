import { AxiosInstance, AxiosResponse } from 'axios';

export type ErrorResponse = {
  statusCode: number;
  trace: string;
};

export type AsyncRunnerMethod = (promise: () => Promise<AxiosResponse>) => Promise<AxiosResponse>;
