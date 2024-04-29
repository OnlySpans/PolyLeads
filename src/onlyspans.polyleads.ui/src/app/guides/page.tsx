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
        <div className='items-start justify-center gap-6 px-0 md:px-8 py-8 md:grid lg:grid-cols-2 xl:grid-cols-3'>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1 mb-6'>
            <Link href={'/guides/iknk-directorate'}>
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
            </Link>

            <Link href={'/guides/may-holidays'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <Image
                    src={'/guides/holidays.jpg'}
                    alt={'/'}
                    width='512'
                    height='512'
                    className='w-full rounded-md object-cover'
                  />
                </CardContent>
                <CardFooter className='flex justify-between'>
                  <CardTitle>Майские праздники</CardTitle>
                </CardFooter>
              </Card>
            </Link>
            <Link href={'/guides/coworking'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <Image
                    src={'/guides/holidays.jpg'}
                    alt={'/'}
                    width='512'
                    height='512'
                    className='w-full rounded-md object-cover'
                  />
                </CardContent>
                <CardFooter className='flex justify-between items-baseline'>
                  <CardTitle>Коворкинги</CardTitle>
                </CardFooter>
              </Card>
            </Link>
          </div>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1 mb-6'>
            <Link href={'/guides/what-to-do-if-you-get-sick'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <Image
                    src={'/guides/holidays.jpg'}
                    alt={'/'}
                    width='512'
                    height='512'
                    className='w-full rounded-md object-cover'
                  />
                </CardContent>
                <CardFooter className='flex justify-between items-baseline'>
                  <CardTitle>Что делать, если ты заболел?</CardTitle>
                </CardFooter>
              </Card>
            </Link>
            <Link href={'/guides/prof'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <Image
                    src={'/guides/holidays.jpg'}
                    alt={'/'}
                    width='512'
                    height='512'
                    className='w-full rounded-md object-cover'
                  />
                </CardContent>
                <CardFooter className='flex justify-between items-baseline'>
                  <CardTitle>ПРОФ</CardTitle>
                </CardFooter>
              </Card>
            </Link>
          </div>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1 mb-6'>
            <Link
              href={
                '/guides/meeting-with-the-deputy-director-of-educational-activities'
              }
            >
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
                <CardFooter className='flex justify-between items-baseline'>
                  <CardTitle>
                    Встреча с зам директора по образовательной деятельности
                  </CardTitle>
                </CardFooter>
              </Card>
            </Link>
            <Link href={'/guides/financial-support'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <Image
                    src={'/guides/holidays.jpg'}
                    alt={'/'}
                    width='512'
                    height='512'
                    className='w-full rounded-md object-cover'
                  />
                </CardContent>
                <CardFooter className='flex justify-between items-baseline'>
                  <CardTitle>Матеральная поддержка</CardTitle>
                </CardFooter>
              </Card>
            </Link>
          </div>
        </div>
      </div>
    </>
  );
};

export default Guides;