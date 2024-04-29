'use client';

import React from 'react';
import { Card, CardContent, CardFooter, CardTitle } from '@/components/ui/card';
import Image from 'next/image';
import Link from 'next/link';
import Header from '@/components/Header/Header';

const Guides = () => {
  return (
    <>
      <Header />
      {/*<div className='container py-8 flex max-w-screen-2xl '>*/}
      {/*  <Input*/}
      {/*    placeholder='Искать по названию'*/}
      {/*    onChange={(event) => {}}*/}
      {/*    className='h-8 w-[200px] lg:w-[250px]'*/}
      {/*  />*/}
      {/*</div>*/}

      <div className='container space-y-8 w-full md:grids-col-2 grid md:gap-4'>
        <div className='items-start justify-center gap-6  p-8 md:grid lg:grid-cols-2 xl:grid-cols-3'>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1'>
            <Link href={'/guides/iknk-directorate'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <Image
                    src={'/polytech.jpg'}
                    alt={'/'}
                    width='512'
                    height='512'
                    className='aspect-square w-full rounded-md object-cover'
                  />
                </CardContent>
                <CardFooter className='flex justify-between'>
                  <CardTitle>Дирекция ИКНК</CardTitle>
                </CardFooter>
              </Card>
            </Link>

            <Card className='w-full shadow hover:bg-accent hover:text-primary'>
              <CardContent className='pt-6'>
                <Image
                  src={'/polytech.jpg'}
                  alt={'/'}
                  width='512'
                  height='512'
                  className='w-full rounded-md object-cover'
                />
              </CardContent>
              <CardFooter className='flex justify-between'>
                <CardTitle>Дирекция ИКНК</CardTitle>
              </CardFooter>
            </Card>
            <Card className='w-full shadow hover:bg-accent hover:text-primary'>
              <CardContent className='pt-6'>
                <Image
                  src={'/guides/holidays.jpg'}
                  alt={'/'}
                  width='512'
                  height='512'
                  className='aspect-square w-full rounded-md object-cover object-right-bottom'
                />
              </CardContent>
              <CardFooter className='flex justify-between items-baseline'>
                <CardTitle>Майские праздники</CardTitle>
                15.04.24
              </CardFooter>
            </Card>
          </div>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1'>
            <Card className='w-full shadow hover:bg-accent hover:text-primary'>
              <CardContent className='pt-6'>
                <Image
                  src={'/guides/holidays.jpg'}
                  alt={'/'}
                  width='512'
                  height='512'
                  className='aspect-square w-full rounded-md object-cover object-right-bottom'
                />
              </CardContent>
              <CardFooter className='flex justify-between items-baseline'>
                <CardTitle>Майские праздники</CardTitle>
                15.04.24
              </CardFooter>
            </Card>
            <Card className='w-full shadow hover:bg-accent hover:text-primary'>
              <CardContent className='pt-6'>
                <Image
                  src={'/guides/holidays.jpg'}
                  alt={'/'}
                  width='512'
                  height='512'
                  className='aspect-square w-full rounded-md object-cover object-right-bottom'
                />
              </CardContent>
              <CardFooter className='flex justify-between items-baseline'>
                <CardTitle>Майские праздники</CardTitle>
                15.04.24
              </CardFooter>
            </Card>
          </div>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-2 lg:grid-cols-2 xl:col-span-1 xl:grid-cols-1'>
            <Card className='w-full shadow hover:bg-accent hover:text-primary'>
              <CardContent className='pt-6'>
                <Image
                  src={'/guides/holidays.jpg'}
                  alt={'/'}
                  width='512'
                  height='512'
                  className='aspect-square w-full rounded-md object-cover object-right-bottom'
                />
              </CardContent>
              <CardFooter className='flex justify-between items-baseline'>
                <CardTitle>Майские праздники</CardTitle>
                15.04.24
              </CardFooter>
            </Card>
            <Card className='w-full shadow hover:bg-accent hover:text-primary'>
              <CardContent className='pt-6'>
                <Image
                  src={'/guides/holidays.jpg'}
                  alt={'/'}
                  width='512'
                  height='512'
                  className='aspect-square w-full rounded-md object-cover object-right-bottom'
                />
              </CardContent>
              <CardFooter className='flex justify-between items-baseline'>
                <CardTitle>Майские праздники</CardTitle>
                15.04.24
              </CardFooter>
            </Card>
          </div>
        </div>
      </div>
    </>
  );
};

export default Guides;