import Header from '@/components/header/header';
import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const GetSickArticle: React.FC = () => {
  return (
    <>
      <BackButton />

      <div className='container md:px-8 px-6 py-4 max-w-screen-md '>
        <h1 className='text-4xl font-bold'>
          Что делать, если тебя застала болезнь?
        </h1>
        <div className='break-words hyphens-auto text-justify space-y-4 mt-4'>
          <p className='text-xl font-semibold'>
            Чувствуешь себя плохо, тогда следуй алгоритму:
          </p>
          <ul className='list-decimal list-inside'>
            <li>Вызови врача</li>
            <li>
              При открытии больничного (листа временной нетрудоспособности),
              сфотографируй (сделай скан) справку (да, без закрывающих данных и
              печатей) и отправь ее скан/фото на почту дирекции (
              <a className='underline decoration-primary'>
                iccs_office@spbstu.ru
              </a>
              ) со своей корпоративной почты с обязательным представлением себя:
              ФИО, номер группы, дата открытия больничного
            </li>
            <li>Лечись, уведоми старосту</li>
            <li>
              По окончании больничного направь повторное письмо со своей
              корпоративной почты на почту дирекции (
              <a className='underline decoration-primary'>
                iccs_office@spbstu.ru
              </a>
              ) в письме пришли скан/фото закрытой справки с обязательным
              представлением себя: ФИО, номер группы, даты больничного
            </li>
            <li>Если продлили больничный, выполни пункт 2</li>
            <li>
              В течение 7 дней после выхода с больничного, необходимо
              предоставить оригинал справки о временной нетрудоспособности в
              дирекцию института — в 3 корпус в 308 аудиторию
            </li>
          </ul>
        </div>
      </div>
    </>
  );
};

export default GetSickArticle;
