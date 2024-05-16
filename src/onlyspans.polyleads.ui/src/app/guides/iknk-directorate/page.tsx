import Header from '@/components/Header/Header';
import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const DirectorateArticle: React.FC = () => {
  return (
    <>
      <Header />
      <BackButton />

      <div className='container md:px-8 px-6 pt-4 pb-12 max-w-screen-md '>
        <h1 className='text-4xl font-bold'>Дирекция ИКНК</h1>
        <p className='break-words  hyphens-auto  text-justify mt-4'>
          Сейчас дирекцию нашего института можно найти на 3 этаже 3 учебного
          корпуса.
        </p>
        <h3 className='text-2xl font-bold py-6'>Часы приёма в дирекции</h3>
        <div className='break-words  hyphens-auto  text-justify space-y-4'>
          <blockquote className='border-l-2 pl-6'>
            <p className='font-semibold'>Когда стоит обратиться в дирекцию:</p>
            <ul className='list-disc list-inside'>
              <li>
                Если необходимо обсудить вопрос административного характера
              </li>
              <li>Староста не дал ответа на вопрос</li>
              <li>Профорг не дал ответа на вопрос</li>
              <li>Адаптер не ответил на вопрос</li>
              <li>Председатель ПРОФ.ИКНК тоже не дал ответа</li>
            </ul>
          </blockquote>

          <ul className='list-decimal list-inside'>
            <li>Приходим в дирекцию — 3 корпус, 308 аудитория</li>
            <li>
              Приходить следует только в часы приема: по средам с{' '}
              <a className='underline decoration-primary'>09:00 до 11:00</a>
            </li>
            <li>Если прийти в другое время, есть риск не получить аудиенцию</li>
          </ul>
        </div>
      </div>
    </>
  );
};

export default DirectorateArticle;
