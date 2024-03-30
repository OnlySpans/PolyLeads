import React from 'react';
import { Container } from 'inversify';
import AuthFormVM, { IAuthFormVM } from '@/components/auth/AuthForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<IAuthFormVM>(ServiceSymbols.IAuthFormVM).to(AuthFormVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;