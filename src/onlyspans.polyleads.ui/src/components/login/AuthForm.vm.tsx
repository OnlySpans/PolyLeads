import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import React from 'react';
import { z } from 'zod';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

export interface IAuthFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  login: (event: React.SyntheticEvent) => void;
  schemaForm: () => z.ZodObject<any>;
}

@injectable()
class AuthFormVM implements IAuthFormVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isPasswordShown: boolean = false;

  private readonly authApi: IAuthApi;

  constructor(@inject(ServiceSymbols.AuthApi) authApi: IAuthApi) {
    this.authApi = authApi;
    makeObservable(this);
  }

  @action
  public togglePasswordShown = () => {
    this.isPasswordShown = !this.isPasswordShown;
  }

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  public readonly schemaForm = (): z.ZodObject<any> => {
    return z.object({
      email: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Имя должно содержать не менее 4 символов'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
    })
  }
}

export default AuthFormVM;
