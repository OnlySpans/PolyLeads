'use client';

import ChatBot from '@/components/chat-bot/chat-bot';
import Header from '@/components/header/header';

const ChatBotPage = () => {
  return (
    <>
      <Header />
      <div className='sm:p-8 px-0 py-4 flex justify-center h-[calc(100vh-3.5rem)]'>
        <ChatBot />
      </div>
    </>
  );
};

export default ChatBotPage;