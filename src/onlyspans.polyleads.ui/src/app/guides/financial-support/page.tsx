import Header from '@/components/header/header';
import React from 'react';
import { BackButton } from '@/components/ui/back-button';

const FinancialSupportArticle: React.FC = () => {
  return (
    <>
      <Header />
      <BackButton />

      <div className='container md:px-8 px-6 pt-4 pb-12 max-w-screen-md'>
        <h1 className='text-4xl font-bold'>МАТЕРИАЛЬНАЯ ПОДДЕРЖКА</h1>
        <div className='break-words  hyphens-auto  text-justify space-y-4'>
          <p className='pt-8'>
            Материальная поддержка — это единовременная денежная выплата
            нуждающимся обучающимся. Источником этой выплаты может быть фонд
            Профсоюзной организации, который формируется из членских взносов,
            или университетский фонд социальной защиты обучающихся.
          </p>
          <p className='pb-8'>
            Если ты попал в сложную ситуацию - свяжись с ПРОФом. Он постарается
            помочь тебе!
          </p>
          <h2 className='border-l-2 pl-6 text-2xl font-bold text-left'>
            Материальная помощь из Фонда ПРОФа
          </h2>
          <p className='pt-4'>
            Фонд Профсоюзной организации формируется за счет членских взносов,
            поэтому этот вид материальной помощи могут получать только студенты
            и аспиранты, состоящие в Профсоюзе (бюджетной и контрактной формы
            обучения). Члены Профсоюза имеют право на получение материальной
            помощи при условии, что членство в Профсоюзе началось раньше, чем
            произошло событие, повлекшее за собой необходимость в оказании
            материальной помощи.
          </p>
          <h3 className='text-xl font-bold py-4 text-left'>
            Что нужно делать, чтобы получить материальную поддержку?
          </h3>
          <ul className='list-decimal list-inside pb-8'>
            <li className='font-semibold pb-2'>Найди свою категорию</li>
            <p>
              Из списка категорий, прописанных в документе, лежащем в разделе
              «Файлы» нашего сообщества, выбери ту, которая подходит тебе
            </p>
            <li className='font-semibold pb-2 pt-8'>Подготовь все документы</li>
            <p>
              Скачай образец обращения, лежащий в разделе «Файлы» нашего
              сообщества, заполни его и приложи подтверждающие документы в
              соответствии с категорией
            </p>
            <li className='font-semibold pb-2 pt-8'>Отнеси документы в ПРОФ</li>
            <p>
              Приходи в 349 кабинет 1-го корпуса с понедельника по четверг с
              10:00 до 17:00, в пятницу с 10:00 до 16:00
            </p>
            <li className='font-semibold pb-2 pt-8'>
              Дождись решения о выплате
            </li>
            <p>
              На последнем в месяце заседании профсоюзного комитета (вторник)
              примут решение о выплате тебе материальной помощи
            </p>
          </ul>

          <h2 className='border-l-2 pl-6 text-2xl font-bold text-left'>
            Материальная помощь из Фонда Университета
          </h2>
          <p className='pt-4'>
            Этот вид материальной поддержки осуществляется из фонда
            Университета. Выплаты могут получать только студенты и аспиранты
            очной и бюджетной формы обучения.
          </p>
          <h3 className='text-xl font-bold py-4 text-left'>
            Что нужно делать, чтобы получить материальную поддержку?
          </h3>
          <ul className='list-decimal list-inside'>
            <li className='font-semibold pb-2'>Найди свою категорию</li>
            <p>
              Из списка категорий, прописанных в документе, лежащем в разделе
              «Файлы» нашего сообщества, выбери ту, которая подходит тебе
            </p>
            <li className='font-semibold pb-2 pt-8'>Подготовь все документы</li>
            <p>
              Скачай образец обращения, лежащий в разделе «Файлы» нашего
              сообщества, заполни его и приложи подтверждающие документы в
              соответствии с категорией
            </p>
            <li className='font-semibold pb-2 pt-8'>
              Отнеси (отнеси) документы
            </li>
            <p>
              Отправь документы через личный кабинет обучающегося, либо приходи
              в 349 кабинет 1-го корпуса (если требуются оригиналы документов) с
              понедельника по четверг с 10:00 до 17:00, в пятницу с 10:00 до
              16:00
            </p>
            <li className='font-semibold pb-2 pt-8'>
              Дождись решения о выплате
            </li>
            <p>
              Если обращение подано до 20 числа месяца, то выплата придёт 25
              числа следующего месяца
            </p>
          </ul>
        </div>
      </div>
    </>
  );
};

export default FinancialSupportArticle;
