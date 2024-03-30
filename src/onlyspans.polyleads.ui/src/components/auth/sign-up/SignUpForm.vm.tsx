import { injectable } from 'inversify';
import { makeObservable } from 'mobx';

export interface ISignUpFormVM {}

@injectable()
class SignUpFormVM implements ISignUpFormVM {

  constructor() {
    makeObservable(this);
  }

}

export default SignUpFormVM;