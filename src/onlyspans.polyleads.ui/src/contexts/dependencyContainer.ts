import React from 'react';
import { Container } from 'inversify';
import SignInFormVM, {
  ISignInFormVM,
} from '@/components/auth/sign-in/SignInFormVM';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import SignUpFormVM, {
  ISignUpFormVM,
} from '@/components/auth/sign-up/SignUpForm.vm';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVM);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;