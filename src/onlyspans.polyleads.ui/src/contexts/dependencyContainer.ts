import React from 'react';
import { Container } from 'inversify';
import AuthFormVM, { IAuthFormVM } from '@/components/login/AuthForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import axios, { AxiosInstance } from 'axios';
import { AuthApi, IAuthApi } from '@/services/api/auth/authApi';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<AxiosInstance>(ServiceSymbols.AxiosInstance).toFactory(() => axios.create({}));
  container.bind<IAuthApi>(ServiceSymbols.AuthApi).to(AuthApi);
  container.bind<IAuthFormVM>(ServiceSymbols.IAuthFormVM).to(AuthFormVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;
