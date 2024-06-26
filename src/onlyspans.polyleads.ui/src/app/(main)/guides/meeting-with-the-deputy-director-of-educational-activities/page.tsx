import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const MeetingWithDirectorArticle: React.FC = () => {
  return (
    <>
      <BackButton />

      <div className='container md:px-8 px-6 pt-4 pb-12 max-w-screen-md '>
        <h1 className='text-4xl font-bold'>
          Что делать, если нужна встреча с заместителем директора института по
          образовательной деятельности?
        </h1>
        <div className='break-words  hyphens-auto  text-justify space-y-4'>
          <p className='font-semibold mt-8'>
            Если необходимо переговорить с заместителем директора института по
            образовательной деятельности, но:
          </p>
          <blockquote className='border-l-2 pl-6'>
            <ul className='list-disc list-inside'>
              <li>Староста не дал ответа на вопрос</li>
              <li>Профорг не дал ответа на вопрос</li>
              <li>Адаптер не ответил на вопрос</li>
              <li>Председатель ПРОФ.ИКНК тоже не дал ответа</li>
            </ul>
          </blockquote>

          <ul className='list-decimal list-inside'>
            <li>Описываем подробно свою проблему в электронном письме</li>
            <li>
              Письмо направляем на почту заместителя директора института по
              образовательной деятельности, Александровой Елены Борисовны (
              <a className='underline decoration-primary'>
                aleksandrova_eb@spbstu.ru
              </a>
              )
            </li>
            <li>Письмо отправляем только со своей корпоративной почты</li>
            <li>Не забываем про представление: ФИО, номер группы</li>
            <li>В ответ получаем дату и время приема</li>
            <li>
              В обозначенный временной промежуток приходим на встречу с
              заместителем директора по образовательной деятельности
            </li>
            <li>
              Если прийти не получается, то в электронном письме сообщаем об
              этом (
              <a className='underline decoration-primary'>
                aleksandrova_eb@spbstu.ru
              </a>
              )
            </li>
          </ul>
        </div>
      </div>
    </>
  );
};

export default MeetingWithDirectorArticle;
