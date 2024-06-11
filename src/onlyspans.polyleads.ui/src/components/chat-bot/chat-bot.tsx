import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import RequestForm from '@/components/chat-bot/request-form/request-input';

const ChatBot: FC = () => {
  return (
    <div className='w-1/2 rounded-2xl border block items-center content-center'>
      <RequestForm />
    </div>
  );
};

export default observer(ChatBot);
