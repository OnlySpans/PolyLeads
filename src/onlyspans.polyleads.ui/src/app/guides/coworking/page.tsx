import Header from '@/components/Header/Header';
import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const CoworkingArticle: React.FC = () => {
  return (
    <>
      <Header />
      <BackButton />

      <div className='container md:px-8 px-6 pt-4 pb-12 max-w-screen-md '>
        <h1 className='text-4xl font-bold'>Коворкинги</h1>
        <div className='break-words  mt-4  hyphens-auto  text-justify space-y-4'>
          <ul className='list-disc list-inside'>
            <li className='text-2xl font-bold py-6'>
              Главное здание, Читальный зал
            </li>
            <p className='font-semibold'>
              Самая большая коворкинг-зона, которая находится в самом сердце
              Политеха. Готова принять вас и практически неограниченное
              количество ваших друзей по будням с 9:00 до 18:00.
            </p>
            <li className='text-2xl font-bold py-6'>2-й корпус, 1 этаж</li>
            <p className='font-semibold'>
              Небольшой коворкинг справа от входа в корпус. За столами,
              находящимися там, сможет комфортно работать команда до четырёх
              человек.
            </p>
            <li className='text-2xl font-bold py-6'>НИК, Зимний сад</li>
            <p className='font-semibold'>
              Здесь также может разместиться компания до четырёх человек. Плюсом
              в сравнении с коворкингом во 2-м корпусе будет удалённость от
              входа и меньшее количество шума, как следствие. Минусом —
              неиллюзорная возможность потеряться в лабиринтах НИКа на пути к
              Зимнему саду.
            </p>
            <li className='text-2xl font-bold py-6'>
              11-й корпус, рекреации на 2 и 3 этажах.
            </li>
            <p className='font-semibold'>
              Можно сказать, что это целый комплекс коворкингов. В 11 корпусе
              есть сразу несколько зон со столами и диванами и всё же здесь
              будет трудно найти место, где можно организовать работу команды
              более чем из пяти человек.
            </p>
            <li className='text-2xl font-bold py-6'>
              4-й корпус, 3 этаж, секция телематики
            </li>
            <p className='font-semibold'>
              Подойдёт для брейншторма самых сложных и трудоёмких задач. Почему
              именно здесь? Потому что здесь получится разместиться группой до
              восьми человек.
            </p>
            <li className='text-2xl font-bold py-6'>
              Гидробашня, Точка кипения
            </li>
            <p className='font-semibold'>
              В Точке кипения можно получить в распоряжение отдельную аудиторию,
              где сможет поместиться команда из 15 человек. Но для этого
              аудиторию нужно предварительно забронировать. тут.
            </p>
          </ul>
        </div>
      </div>
    </>
  );
};

export default CoworkingArticle;
