'use client';
import { LoaderCircle } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import React from 'react';
import useGet from '@/hooks/useGet';
import { IAuthFormVM } from '@/components/login/AuthForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

interface IAuthFormProps extends React.HTMLAttributes<HTMLDivElement> {}

const AuthForm: React.FC<IAuthFormProps> = () => {
  const vm = useGet<IAuthFormVM>(ServiceSymbols.IAuthFormVM);

  const [isLoading, setIsLoading] = React.useState<boolean>(false);

  async function onSubmit(event: React.SyntheticEvent) {
    event.preventDefault();
    setIsLoading(true);

    setTimeout(() => {
      setIsLoading(false);
    }, 3000);
  }

  return (
    <div className={'grid gap-6'}>
      <form onSubmit={onSubmit}>
        <div className='grid gap-2'>
          <div className='grid gap-1'>
            <Input
              id='email'
              minLength={4}
              required={true}
              placeholder='Имя пользователя или email'
              autoComplete='email'
              autoCorrect='off'
              disabled={isLoading}
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
              disabled={isLoading}
            />
          </div>
          <Button disabled={isLoading}>
            {isLoading ? (
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

export default AuthForm;