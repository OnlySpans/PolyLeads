'use client';
import { LoaderCircle } from 'lucide-react';
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
              placeholder='Имя пользователя или email'
              autoComplete='email'
              autoCorrect='off'
              disabled={vm.isLoading}
            />
          </div>
          <div className='grid gap-1'>
            <Input
              id='password'
              minLength={6}
              required={true}
              placeholder='Пароль'
              autoComplete='off'
              autoCorrect='off'
              disabled={vm.isLoading}
            />
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