import React from 'react';
import {
  Card, CardContent,
  CardDescription, CardFooter, CardHeader,
  CardTitle
} from '@/components/ui/card';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import { Button } from '@/components/ui/button';

const UploadDocumentModal: React.FC = () => {
  return (
    <Card className="w-[350px]">
      <CardHeader>
        <CardTitle>Загрузить документ</CardTitle>
        <CardDescription>Распознавание текста</CardDescription>
      </CardHeader>
      <CardContent>
        <form>
          <div className="grid w-full items-center gap-4">
            <div className="flex flex-col space-y-3">
              <Label htmlFor="document-title">Название документа</Label>
              <Input id="document-title" placeholder="Название" />
            </div>
            <div className="flex flex-col space-y-3">
              <Label htmlFor="source-link">Ссылка на файл</Label>
              <Input id="source-link" placeholder="Ссылка" />
            </div>
          </div>
        </form>
      </CardContent>
      <CardFooter className="flex justify-between">
        <Button variant="outline">Отменить</Button>
        <Button>Добавить</Button>
      </CardFooter>
    </Card>
  );
}

export default UploadDocumentModal;
