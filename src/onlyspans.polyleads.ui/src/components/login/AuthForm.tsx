'use client';

import { EyeIcon, EyeOffIcon, LoaderCircle } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import React from 'react';
import useGet from '@/hooks/useGet';
import { observer } from 'mobx-react-lite';
import { IAuthFormVM } from '@/components/login/AuthForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

interface IAuthFormProps {}

const AuthForm: React.FC<IAuthFormProps> = () => {
  const vm = useGet<IAuthFormVM>(ServiceSymbols.IAuthFormVM);

  return (
    <div className={'grid gap-6'}>
      <form onSubmit={vm.login}>
        <div className='grid gap-2'>
          <div className='grid gap-1'>
            <Input
              id='email'
              minLength={4}
              required={true}
              placeholder='Имя пользователя или почта'
              autoComplete='email'
              autoCorrect='off'
              disabled={vm.isLoading}
            />
          </div>
          <div className='relative'>
            <Input
              id='password'
              type={vm.isPasswordShown ? 'text' : 'password'}
              minLength={6}
              required={true}
              placeholder='Пароль'
              autoComplete='new-password'
              autoCorrect='off'
              disabled={vm.isLoading}
            />
            <Button
              type='button'
              variant='ghost'
              className='absolute top-0 right-0 px-3 py-2 hover:bg-transparent'
              onClick={() => vm.setPasswordShown(!vm.isPasswordShown)}
            >
              {vm.isPasswordShown ? (
                <EyeOffIcon className='h-4 w-4' />
              ) : (
                <EyeIcon className='h-4 w-4' />
              )}
            </Button>
          </div>
          <Button disabled={vm.isLoading}>
            {vm.isLoading ? (
              <>
                <LoaderCircle className='mr-2 h-4 w-4 animate-spin' />
                Подождите
              </>
            ) : (
              'Войти'
            )}
          </Button>
        </div>
      </form>
    </div>
  );
}

export default observer(AuthForm);