'use client';

import React from 'react';
import { Card, CardContent, CardFooter, CardTitle } from '@/components/ui/card';
import Link from 'next/link';
import Header from '@/components/Header/Header';

const Guides: React.FC = () => {
  return (
    <>
      <Header />
      <div className='container space-y-8 w-full md:grids-col-2 grid md:gap-4'>
        <div className='items-start justify-center gap-6 px-0 md:px-8 py-8 md:grid lg:grid-cols-2 xl:grid-cols-3'>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1 mb-6'>
            <Link href={'/guides/what-to-do-if-you-get-sick'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <img
                    src={
                      'https://cgon.rospotrebnadzor.ru/upload/iblock/b9f/3ot7fujsv2kd3pmumn5s2261zvkvb60u/%D0%A7%D1%82%D0%BE%20%D0%B4%D0%B5%D0%BB%D0%B0%D1%82%D1%8C%2C%20%D0%B5%D1%81%D0%BB%D0%B8%20%D0%B2%D1%8B%20%D0%B7%D0%B0%D0%B1%D0%BE%D0%BB%D0%B5%D0%BB%D0%B8_0.png'
                    }
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
                  <img
                    src={
                      'https://sun9-35.userapi.com/impf/hwAPw5DrmVWtd859C7hmzx6zWhdhLP3Eiwo9qA/RydYFTEdV0c.jpg?size=1920x768&quality=95&crop=0,0,1920,767&sign=5bb602ec6c8c6d1afab33e916915a80a&type=cover_group'
                    }
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
            <Link
              href={
                '/guides/meeting-with-the-deputy-director-of-educational-activities'
              }
            >
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <img
                    src={
                      'https://hedclub.com/data/pub/175/VCWa3ZWcOjrOpyJuplx5.jpg'
                    }
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
          </div>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1 mb-6'>
            <Link href={'/guides/iknk-directorate'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <img
                    src={
                      'https://avatars.mds.yandex.net/get-altay/1526642/2a0000016a3fe4aeff1c24c916b9dd759f60/orig'
                    }
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
                  <img
                    src={
                      'https://hotel-sofrino.ru/wp-content/uploads/2024/01/Majskie-prazdniki-2024.jpeg'
                    }
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
          </div>
          <div className='col-span-2 grid items-start gap-6 lg:col-span-1 mb-6'>
            <Link href={'/guides/coworking'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <img
                    src={'https://imet.spbstu.ru/userfiles/images/Open_2.jpg'}
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
            <Link href={'/guides/financial-support'}>
              <Card className='w-full shadow hover:bg-accent hover:text-primary'>
                <CardContent className='pt-6'>
                  <img
                    src={
                      'https://i.klerk.ru/1m3LwngTm-3WKc5nDl_ukRY_tW2uKQzNJnRpNSjhadQ/w:1500/aHR0cHM6Ly93d3cu/a2xlcmsucnUvdWdj/L2Jsb2dQb3N0Lzcz/MmU4YTkzMTEzMmQ3/OTUxMGJkMWY0NDVm/NmY1YWJiLmpwZw.webp'
                    }
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
