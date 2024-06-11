import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import RequestForm from '@/components/chat-bot/request-form/request-form';
import { ScrollArea } from '@/components/ui/scroll-area';

const ChatBot: FC = () => {
  return (
    <div className='md:w-1/2 px-4 w-full flex flex-col items-center content-center justify-between'>
      <ScrollArea className='w-full h-screen rounded-md border p-4 mb-6'>
        so funny that they couldn't help but laugh. And once they started
      </ScrollArea>
      <div className='w-full'>
        <RequestForm />
      </div>
    </div>
  );
};

export default observer(ChatBot);
