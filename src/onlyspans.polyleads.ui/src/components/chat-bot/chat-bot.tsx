'use client';

import { observer } from 'mobx-react-lite';
import { FC, useEffect } from 'react';
import RequestForm from '@/components/chat-bot/request-form/request-form';
import { ScrollArea } from '@/components/ui/scroll-area';
import { Avatar, AvatarFallback, AvatarImage } from '@/components/ui/avatar';
import moment from 'moment/moment';
import RequestExamplesCards from '@/components/chat-bot/request-examples-cards/request-examples-cards';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';

const ChatBot: FC = () => {
  const vm = useGet<IChatBotVM>(ServiceSymbols.IChatBotVM);

  useEffect(() => {
    vm.scrollToBottom();
  }, [vm.messages]);

  return (
    <div className='xl:w-1/2 md:w-2/3 px-4 w-full flex flex-col items-center content-center justify-between'>
      {vm.messages.length !== 0 ? (
        <ScrollArea className='w-full h-screen rounded-md border md:px-4 px-2 mb-6'>
          {vm.messages.map((message) => (
            <>
              <div
                className={`my-4 flex items-end gap-2 ${message.type === 'bot' ? 'justify-start' : 'flex-row-reverse'}`}
              >
                {message.type === 'bot' ? (
                  <Avatar className='sm:block hidden'>
                    <AvatarImage src='https://github.asdasdcom/shadcn.png' />
                    <AvatarFallback>AI</AvatarFallback>
                  </Avatar>
                ) : (
                  <Avatar className='sm:block hidden'>
                    <AvatarImage src='' />
                    <AvatarFallback>{'^-^'}</AvatarFallback>
                  </Avatar>
                )}
                <div className='sm:w-3/4 w-5/6 bg-accent p-4 border rounded-md'>
                  <p>{message.text}</p>
                  <p className='text-muted-foreground text-right text-xs mb-[-8px] mr-[-4px]'>
                    {moment(message.timestamp).format('HH:mm')}
                  </p>
                </div>
              </div>
            </>
          ))}
          <div ref={vm.messagesEndRef} />
        </ScrollArea>
      ) : (
        <div className='w-full h-screen rounded-md border md:px-4 px-2 mb-6'>
          <div className='flex h-full justify-center items-center content-center'>
            <RequestExamplesCards />
          </div>
        </div>
      )}
      <div className='w-full'>
        <RequestForm />
      </div>
    </div>
  );
};

export default observer(ChatBot);
