'use client';

import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import { ScrollArea } from '@/components/ui/scroll-area';
import PromptSampleCards from '@/components/chat-bot/prompt-sample-cards/prompt-sample-cards';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';
import PromptInput from "@/components/chat-bot/prompt-input/prompt-input";
import BotMessage from '@/components/chat-bot/messages/BotMessage';
import UserMessage from '@/components/chat-bot/messages/UserMessage';
import MessageLoader from '@/components/chat-bot/messages/MessageLoader';

const ChatBot: FC = () => {
  const vm = useGet<IChatBotVM>(ServiceSymbols.IChatBotVM);

  return (
    <div className='xl:w-1/2 md:w-2/3 px-4 w-full flex flex-col gap-4 items-center content-center justify-between'>
      {vm.messages.length !== 0 ? (
        <ScrollArea className='w-full h-screen rounded-md border md:px-4 px-2'>
          {vm.messages.map((message, index) => (
            <>
              {
                message.sender === 'bot'
                ? <BotMessage message={message}  index={index}/>
                : <UserMessage message={message}  index={index}/>
              }
            </>
          ))}
          <MessageLoader />
          <div ref={vm.messagesEndRef} />
        </ScrollArea>
      ) : (
        <div className='w-full h-screen rounded-md border md:px-4 px-2'>
          <div className='flex h-full justify-center items-center content-center'>
            <PromptSampleCards />
          </div>
        </div>
      )}
      <div className='w-full'>
        <PromptInput />
      </div>
    </div>
  );
};

export default observer(ChatBot);
