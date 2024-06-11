import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import RequestForm from '@/components/chat-bot/request-form/request-form';

const ChatBot: FC = () => {
  return (
    <div className='w-1/2 rounded-2xl border block items-center content-center'>
      <div className='flex p-8'>
        <div className='w-full rounded-md border block items-center content-center'>
          asdas
        </div>
      </div>
      <RequestForm />
    </div>
  );
};

export default observer(ChatBot);
