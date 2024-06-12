import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import RequestForm from '@/components/chat-bot/request-form/request-form';
import { ScrollArea } from '@/components/ui/scroll-area';
import { Messages } from '@/components/chat-bot/chat-bot.test-data';
import { Avatar, AvatarFallback, AvatarImage } from '@/components/ui/avatar';

const ChatBot: FC = () => {
  return (
    <div className='md:w-1/2 px-4 w-full flex flex-col items-center content-center justify-between'>
      <ScrollArea className='w-full h-screen rounded-md border p-4 mb-6'>
        {Messages.map((message) => (
          <>
            <div
              className={`mt-4 flex items-end gap-2  ${message.type === 'bot' ? 'justify-start' : 'justify-end'}`}
            >
              {message.type === 'bot' ? (
                <Avatar>
                  <AvatarImage src='https://github.asdasdcom/shadcn.png' />
                  <AvatarFallback>AI</AvatarFallback>
                </Avatar>
              ) : (
                ''
              )}
              <div className='w-3/4 bg-accent p-4 border rounded-md'>
                {message.text}
              </div>
              {message.type === 'user' ? (
                <Avatar>
                  <AvatarImage src='https://asdsadsa' />
                  <AvatarFallback>{'^-^'}</AvatarFallback>
                </Avatar>
              ) : (
                ''
              )}
            </div>
          </>
        ))}
      </ScrollArea>
      <div className='w-full'>
        <RequestForm />
      </div>
    </div>
  );
};

export default observer(ChatBot);
