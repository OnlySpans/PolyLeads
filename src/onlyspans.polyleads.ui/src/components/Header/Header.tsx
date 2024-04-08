import React from 'react';
import { Cookie } from 'lucide-react';
import Link from 'next/link';
import { cn } from '@/lib/utils';
import { buttonVariants } from '@/components/ui/button';
import { ThemeSwitchButton } from '@/components/ui/ThemeSwitchButton';

interface IHeaderProps {}

const Header: React.FC<IHeaderProps> = () => {
  return (
    <header className='sticky top-0 z-50 w-full border-b border-border/70 bg-background/95'>
      <div className='container flex h-14 max-w-screen-2xl items-center'>
        <div className='flex gap-4'>
          <Cookie className='text-primary ml-1' />
          <nav className='flex items-center gap-4 text-sm'>
            <Link
              href='/'
              className='text-sm font-medium transition-colors hover:text-primary'
            >
              Something
            </Link>
            <Link
              href='/'
              className='text-sm font-medium text-muted-foreground transition-colors hover:text-primary'
            >
              Settings
            </Link>
          </nav>
        </div>
        <div className='flex flex-1 items-center space-x-2 justify-end'>
          <Link
            href={'/auth/sign-in'}
            className={cn(
              buttonVariants({
                variant: 'default',
              }),
            )}
          >
            Войти
          </Link>
          <ThemeSwitchButton />
        </div>
      </div>
    </header>
  );
};

export default Header;
