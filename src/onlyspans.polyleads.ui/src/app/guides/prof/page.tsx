import Header from '@/components/header/header';
import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const ProfArticle: React.FC = () => {
  return (
    <>
      <Header />
      <BackButton />

      <div className='container md:px-8 px-6 pt-4 pb-12 max-w-screen-md '>
        <h1 className='text-4xl font-bold'>ПРОФ</h1>
        <div className='break-words  hyphens-auto mt-4 text-justify space-y-4'>
          <blockquote className='border-l-2 pl-6 py-2'>
            <p className='font-semibold text-2xl'>ЧТО ТАКОЕ ПРОФ?</p>
          </blockquote>
          <p>
            Профсоюзная организация обучающихся СПбПУ основана в 1965 году и
            является независимой некоммерческой неполитической организацией
            обучающихся университета. ПРОФ — одно из крупнейших студенческих
            объединений в Санкт-Петербурге и самая крупная первичная профсоюзная
            организация в городе.
          </p>
          <blockquote className='border-l-2 pl-6 py-2'>
            <p className='font-semibold text-2xl'>ЧЕМ ЗАНИМАЕТСЯ ПРОФ?</p>
          </blockquote>
          <ul className='list-disc list-inside space-y-4'>
            <li className='font-bold'>
              Представляет интересы студентов перед администрацией
            </li>
            <p>
              Благодаря представителям в Учёном совете Университета и институтов
              ПРОФ принимает участие в важных решениях на равных с
              администрацией.
            </p>
            <li className='font-bold'>Защищает права студентов</li>
            <p>
              ПРОФ отстаивает права обучающихся в разных сферах: от конфликта с
              преподавателем до права всех студентов на полноценные каникулы и
              повышение размера стипендии.
            </p>
            <li className='font-bold'>
              Занимается организацией отдыха студентов
            </li>
            <p>
              ПРОФ организовывает как культурный досуг в течение учебных
              семестров, так и летний и зимний отдых студентов на базах
              Университета.
            </p>
            <li className='font-bold'>
              Обменивается опытом с другими университетами
            </li>
            <p>
              ПРОФ держит связь со студенческими профсоюзами разных вузов нашего
              города и страны, а также отправляет представителей на региональные
              и федеральные конкурсы.
            </p>
            <li className='font-bold'>Создает университетские мероприятия</li>
            <p>
              Для поддержки талантливой молодёжи ПРОФ ежегодно проводит такие
              конкурсы как «Polytech Project», «Политех Фото», «Мистер и Мисс
              Политех», «Студент года», а также организовывает образовательные
              семинары «Студенческая перспектива», «Профучёба».
            </p>
            <li className='font-bold'>Поддерживает студенческие организации</li>
            <p>
              ПРОФ сотрудничает и делает совместные проекты со штабом
              студенческих отрядов, военно-историческим клубом «Наш Политех»,
              студенческим спортивным клубом «Политехник», Общественным
              институтом «Адаптеры».
            </p>
          </ul>
          <blockquote className='border-l-2 pl-6 py-2'>
            <p className='font-semibold text-2xl'>КОНТАКТЫ</p>
          </blockquote>
          <p>
            Цель ПРОФа — быть опорой и помощником для каждого студента, поэтому
            ты всегда можешь обратиться к представителю профбюро твоего
            института или обратиться к нам любым удобным способом: написать в
            соцсетях или на почту, позвонить или же прийти лично. В любом случае
            мы постараемся ответить на все твои вопросы!
          </p>
          <div className='space-y-2'>
            <p>
              Телефон:{' '}
              <a className='underline decoration-primary'>+7(812) 552-98-47</a>
            </p>
            <p>
              Почта:{' '}
              <a className='underline decoration-primary'>profstu@gmail.com</a>
            </p>
            <p>Адрес: СПбПУ, 1-ый учебный корпус, 349 каб.</p>
            <p className='text-xl pt-4'>Время работы:</p>
            <p>пн-чт с 10:00 до 17:00</p>
            <p>пт с 10:00 до 16:00</p>
            <p>
              <a className='underline decoration-primary'>
                13:00-14:00 - обеденный перерыв
              </a>
            </p>
          </div>
        </div>
      </div>
    </>
  );
};

export default ProfArticle;
