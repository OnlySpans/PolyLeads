'use client';

import React from 'react';
import Link from 'next/link';
import { Button } from '@/components/ui/button';
import { ThemeSwitchButton } from '@/components/ui/theme-switch-button';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IHeaderVM } from './header.vm';
import { useRouter } from 'next/navigation';
import { observer } from 'mobx-react-lite';
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover';
import { headerLinks } from './header.links';
import { AlignLeft } from 'lucide-react';

interface IHeaderProps {}

const Header: React.FC<IHeaderProps> = () => {
  const vm = useGet<IHeaderVM>(ServiceSymbols.IHeaderVM);

  const router = useRouter();

  return (
    <header className='sticky top-0 z-50 w-full border-b border-border/70 bg-background/95
      backdrop-blur supports-[backdrop-filter]:bg-background/60'
    >
      <div className='container sm:px-8 px-4 flex h-14 max-w-screen-2xl items-center'>
        <div className='flex gap-3'>
          <div className='hidden sm:flex gap-3 items-center font-medium text-xl mr-4'>
            <img src={'/logoPolytech.svg'} className='w-7' alt={''} />
            <p>PolyLeads</p>
          </div>
          <div className='sm:hidden flex'>
            <Popover>
              <PopoverTrigger>
                <AlignLeft />
              </PopoverTrigger>
              <PopoverContent className='flex flex-col gap-4 ml-4 w-[150px]'>
                  {headerLinks.map((link) => (
                    <Link
                      href={link.href}
                      className='text-base font-medium'
                    >
                      {link.name}
                    </Link>
                  ))}
              </PopoverContent>
            </Popover>
          </div>
          <nav className='sm:flex hidden items-center gap-4 text-sm'>
            {headerLinks.map((link) => (
              <Link
                href={link.href}
                className='text-base font-medium text-muted-foreground transition-colors hover:text-primary'
              >
                {link.name}
              </Link>
            ))}
          </nav>
        </div>
        <div className='flex flex-1 items-center space-x-2 justify-end'>
          <Button
            size='sm'
            className={`${vm.isSignInButtonEnabled ? '' : 'hidden'}`}
            onClick={() => router.push('/sign-in')}
          >
            Войти
          </Button>
          <ThemeSwitchButton />
        </div>
      </div>
    </header>
  );
};

export default observer(Header);
