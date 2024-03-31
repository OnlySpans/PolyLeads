import React from 'react';
import { Container } from 'inversify';
import AuthFormVM, { IAuthFormVM } from '@/components/auth/AuthForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import SignUpFormVM, {
  ISignUpFormVM,
} from '@/components/auth/sign-up/SignUpForm.vm';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<IAuthFormVM>(ServiceSymbols.IAuthFormVM).to(AuthFormVM);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;