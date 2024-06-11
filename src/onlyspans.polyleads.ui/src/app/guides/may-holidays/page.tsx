import Header from '@/components/header/header';
import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const MayHolidaysArticle: React.FC = () => {
  return (
    <>
      <Header />
      <BackButton />

      <div className='container md:px-8 px-6 pt-4 pb-12 max-w-screen-md '>
        <h1 className='text-4xl font-bold'>Майские праздники</h1>
        <div className='break-words  hyphens-auto mt-4 text-justify space-y-4'>
          <p className='font-semibold'>
            Долгожданный майский отдых не за горами!
          </p>
          <ul className='list-disc list-inside'>
            <li>Если необходимо обсудить вопрос административного характера</li>
            <li>
              27 апреля (суббота) — рабочий и учебный день, занятия по
              расписанию субботы
            </li>
            <li>28 апреля (воскресенье) — выходной день </li>
            <li>
              29 апреля (понедельник) — учебный день, выходной день для
              административно-управленческого персонала
            </li>
            <li>
              30 апреля (вторник) — сокращенный учебный день, выходной день для
              административно-управленческого персонала
            </li>
            <li>
              1 мая (среда) — Праздник Весны и Труда, нерабочий праздничный день
            </li>
            <li>
              2 мая (четверг) — рабочий и учебный день, занятия по расписанию{' '}
            </li>
            <li>8 мая (среда) — сокращенный рабочий и учебный день </li>
            <li>9 мая (четверг) — День Победы, нерабочий праздничный день </li>
            <li>10-12 мая — выходные дни </li>
            <li>
              13 мая (среда) — рабочий и учебный день, занятия по расписанию
            </li>
          </ul>
        </div>
      </div>
    </>
  );
};

export default MayHolidaysArticle;
