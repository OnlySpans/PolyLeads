import { IRequestFormVM } from '@/components/chat-bot/request-form/request-form.vm';

const ServiceSymbols = {
  IAuthFormVM: Symbol.for('IAuthFormVM'),
  AxiosInstance: Symbol.for('AxiosInstance'),
  AuthApi: Symbol.for('AuthApi'),
  IDocumentApi: Symbol.for('IDocumentApi'),
  IRoleApi: Symbol.for('IRoleApi'),
  ISignInFormVM: Symbol.for('IAuthFormVM'),
  ISignUpFormVM: Symbol.for('ISignUpFormVM'),
  IDocumentsTableVM: Symbol.for('IDocumentsTableVM'),
  IUploadDocumentModalVM: Symbol.for('IUploadDocumentModalVM'),
  IHeaderVM: Symbol.for('IHeaderVM'),
  IDocumentEditingModalVM: Symbol.for('IDocumentEditingModalVM'),
  IRequestFormVM: Symbol.for('IRequestFormVM'),
};

export default ServiceSymbols;
