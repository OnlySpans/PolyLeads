import React from 'react';
import { Container } from 'inversify';
import SignInFormVM, {
  ISignInFormVM,
} from '@/components/auth/sign-in/sign-in-form.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import axios, { AxiosInstance } from 'axios';
import { AuthApi, IAuthApi } from '@/services/api/auth/authApi';
import SignUpFormVM, {
  ISignUpFormVM,
} from '@/components/auth/sign-up/sign-up-form.vm';
import DocumentsTableVM, {
  IDocumentsTableVM,
} from '@/components/documents/documents-table/documents-table.vm';
import EditDocumentModalVM, {
  IEditDocumentModalVM,
} from '@/components/documents/edit-document-modal/edit-document-modal.vm';
import UploadDocumentModalVM, {
  IUploadDocumentModalVM,
} from '@/components/documents/upload-document-modal/upload-document-modal.vm';
import { DocumentApi, IDocumentApi } from '@/services/api/document/documentApi';
import { IUserRoleApi, UserRoleApi } from '@/services/api/role/userRoleApi';
import HeaderVM, { IHeaderVM } from '@/components/header/header.vm';
import RequestFormVM, {
  IRequestFormVM,
} from '@/components/chat-bot/request-form/request-form.vm';
import ChatBotVM, { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVM);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);
  container
    .bind<IDocumentsTableVM>(ServiceSymbols.IDocumentsTableVM)
    .to(DocumentsTableVM)
    .inSingletonScope();
  container
    .bind<AxiosInstance>(ServiceSymbols.AxiosInstance)
    .toFactory(() => axios.create({}));
  container.bind<IAuthApi>(ServiceSymbols.AuthApi).to(AuthApi);
  container.bind<IDocumentApi>(ServiceSymbols.IDocumentApi).to(DocumentApi);
  container.bind<IUserRoleApi>(ServiceSymbols.IRoleApi).to(UserRoleApi);
  container
    .bind<IUploadDocumentModalVM>(ServiceSymbols.IUploadDocumentModalVM)
    .to(UploadDocumentModalVM);
  container.bind<IHeaderVM>(ServiceSymbols.IHeaderVM).to(HeaderVM);
  container
    .bind<IEditDocumentModalVM>(ServiceSymbols.IEditDocumentModalVM)
    .to(EditDocumentModalVM);
  container
    .bind<IRequestFormVM>(ServiceSymbols.IRequestFormVM)
    .to(RequestFormVM);
  container
    .bind<IChatBotVM>(ServiceSymbols.IChatBotVM)
    .to(ChatBotVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;