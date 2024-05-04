import React from 'react';
import { observer } from 'mobx-react-lite';
import {
  Dialog, DialogClose,
  DialogContent, DialogDescription, DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';

const UploadDocumentModal: React.FC = () => {
  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="default">Добавить файл</Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[425px]">
        <DialogHeader>
          <DialogTitle>Добавить файл</DialogTitle>
          <DialogDescription>
            Файл будет распознан спустя некоторое время
          </DialogDescription>
        </DialogHeader>
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
        <DialogFooter>
          <DialogClose asChild className="m-1">
            <Button type="button" variant="secondary">
              Отмена
            </Button>
          </DialogClose>
          <Button type="submit" className="m-1">Загрузить</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  )
}

export default observer(UploadDocumentModal);
