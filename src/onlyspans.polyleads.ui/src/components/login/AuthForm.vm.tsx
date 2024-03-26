import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import React from 'react';

export interface IAuthFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  setPasswordShown: (isPasswordShown: boolean) => void;
  login: (event: React.SyntheticEvent) => void;
}

@injectable()
class AuthFormVM implements IAuthFormVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isPasswordShown: boolean = false;

  constructor() {
    makeObservable(this);
  }

  @action
  public setPasswordShown = (isPasswordShown: boolean) => {
    this.isPasswordShown = isPasswordShown;
}

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action
  public login = async (event: React.SyntheticEvent) => {
    event.preventDefault();
    this.setIsLoading(true);

    setTimeout(() => {
      this.setIsLoading(false);
    }, 3000);
  }
}

export default AuthFormVM;
