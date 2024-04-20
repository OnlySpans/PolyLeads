import { AxiosInstance, AxiosResponse } from 'axios';

export type ErrorResponse = {
  statusCode: number;
  trace: string;
};

export type Props = {
  onError: (error: unknown) => void;
  api: AxiosInstance;
};

export type AsyncRunnerMethod = (promise: () => Promise<AxiosResponse>) => Promise<AxiosResponse>;
