import React from 'react';
import { Container } from 'inversify';
import SignInFormVM, {
  ISignInFormVM,
} from '@/components/auth/sign-in/SignInFormVM';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import axios, { AxiosInstance } from 'axios';
import { AuthApi, IAuthApi } from '@/services/api/auth/authApi';
import SignUpFormVM, {
  ISignUpFormVM,
} from '@/components/auth/sign-up/SignUpForm.vm';
import DocumentsTableVM, {
  IDocumentsTableVM,
} from '@/components/DocumentsManager/DocumentsTable/DocumentsTableVM';
import DocumentEditingModalVM, {
  IDocumentEditingModalVM,
} from '@/components/DocumentsManager/documents/DocumentEditingModal/DocumentEditingModal.vm';
import UploadDocumentModalVM, { IUploadDocumentModalVM } from '@/components/documents/upload-modal/UploadDocumentModal.vm';
import { DocumentApi, IDocumentApi } from '@/services/api/document/documentApi';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVM);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);
  container.bind<IDocumentsTableVM>(ServiceSymbols.IDocumentsTableVM).to(DocumentsTableVM).inSingletonScope();
  container.bind<AxiosInstance>(ServiceSymbols.AxiosInstance).toFactory(() => axios.create({}));
  container.bind<IAuthApi>(ServiceSymbols.AuthApi).to(AuthApi);
  container.bind<IDocumentApi>(ServiceSymbols.IDocumentApi).to(DocumentApi);
  container.bind<IUploadDocumentModalVM>(ServiceSymbols.IUploadDocumentModalVM).to(UploadDocumentModalVM);
  container.bind<IDocumentEditingModalVM>(ServiceSymbols.IDocumentEditingModalVM).to(DocumentEditingModalVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;