import React from 'react';
import { Container } from 'inversify';
import SignInFormVm, {
  ISignInFormVM,
} from '@/components/auth/sign-in/SignInForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import axios, { AxiosInstance } from 'axios';
import { AuthApi, IAuthApi } from '@/services/api/auth/authApi';
import SignUpFormVM, {
  ISignUpFormVM,
} from '@/components/auth/sign-up/SignUpForm.vm';
import DocumentsTableVM, {
  IDocumentsTableVM,
} from '@/components/DocumentsManager/DocumentsTable/DocumentsTableVM';
import UploadDocumentModalVM, { IUploadDocumentModalVM } from '@/components/documents/upload-modal/UploadDocumentModal.vm';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVm);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);
  container.bind<IDocumentsTableVM>(ServiceSymbols.IDocumentsTableVM).to(DocumentsTableVM);
  container.bind<AxiosInstance>(ServiceSymbols.AxiosInstance).toFactory(() => axios.create({}));
  container.bind<IAuthApi>(ServiceSymbols.AuthApi).to(AuthApi);
  container.bind<IUploadDocumentModalVM>(ServiceSymbols.IUploadDocumentModalVM).to(UploadDocumentModalVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;
