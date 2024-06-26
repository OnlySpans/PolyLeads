'use client';

import ChatBot from '@/components/chat-bot/chat-bot';

const ChatBotPage = () => {
  return (
    <>
      <div className='sm:p-6 px-0 py-4 flex justify-center h-[calc(100vh-3.6rem)]'>
        <ChatBot />
      </div>
    </>
  );
};

export default ChatBotPage;