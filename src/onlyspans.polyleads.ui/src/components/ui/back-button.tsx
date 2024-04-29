'use client';

import { ArrowLeft } from 'lucide-react';
import * as React from 'react';
import { useRouter } from 'next/navigation';

export const BackButton = () => {
  const router = useRouter();
  const goBack = () => {
    router.back();
  };

  return (
    <button onClick={goBack}>
      <div
        className='hidden absolute lg:flex justify-center z-10 hover:bg-accent h-svh w-[6rem] top-0
          hover:text-accent-foreground text-muted-foreground'
      >
        <div className='mt-28'>
          <ArrowLeft />
        </div>
      </div>
    </button>
  );
};