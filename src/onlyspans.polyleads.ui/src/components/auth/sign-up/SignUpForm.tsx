'use client';

import React from 'react';
import useGet from '@/hooks/useGet';
import { IAuthFormVM } from '@/components/auth/login/AuthForm.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { z } from 'zod';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage,
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { Button } from '@/components/ui/button';
import { EyeIcon, EyeOffIcon, LoaderCircle } from 'lucide-react';

interface ISignUpFormProps {}

const SignUpForm: React.FC<ISignUpFormProps> = () => {
  const vm = useGet<IAuthFormVM>(ServiceSymbols.IAuthFormVM);

  const form = useForm<z.infer<typeof vm.schemaForm>>({
    resolver: zodResolver(vm.schemaForm),
  });

  return (
    <Form {...form}>
      <form
        // onSubmit={form.handleSubmit(() => vm.login)}
        className='grid gap-2'
      >
        <FormField
          control={form.control}
          name='username'
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <Input
                  id='email'
                  placeholder='Имя пользователя'
                  autoComplete='email'
                  autoCorrect='off'
                  disabled={vm.isLoading}
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name='username'
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <Input
                  id='email'
                  placeholder='Почта'
                  autoComplete='email'
                  autoCorrect='off'
                  disabled={vm.isLoading}
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name='password'
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <div className='relative'>
                  <Input
                    id="password"
                    type={vm.isPasswordShown ? 'text' : 'password'}
                    placeholder='Пароль'
                    autoComplete="new-password"
                    autoCorrect="off"
                    disabled={vm.isLoading}
                    {...field}
                  />
                  <Button
                    type='button'
                    variant='ghost'
                    className='absolute top-0 right-0 px-3 py-2 hover:bg-transparent'
                    onClick={vm.togglePasswordShown}
                  >
                    {vm.isPasswordShown ? (
                      <EyeOffIcon className='h-4 w-4' />
                    ) : (
                      <EyeIcon className='h-4 w-4' />
                    )}
                  </Button>
                </div>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        /><FormField
          control={form.control}
          name='password'
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <div className='relative'>
                  <Input
                    id="password"
                    type={vm.isPasswordShown ? 'text' : 'password'}
                    placeholder='Пароль'
                    autoComplete="new-password"
                    autoCorrect="off"
                    disabled={vm.isLoading}
                    {...field}
                  />
                </div>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button
          type='submit'
          disabled={vm.isLoading}
        >
          {vm.isLoading ? (
            <>
              <LoaderCircle className='mr-2 h-4 w-4 animate-spin' />
              Подождите
            </>
          ) : (
            'Войти'
          )}
        </Button>
        <Input
          className='hidden'
          type={vm.isPasswordShown ? 'text' : 'password'}
        />
      </form>
    </Form>
  )
}

export default SignUpForm;