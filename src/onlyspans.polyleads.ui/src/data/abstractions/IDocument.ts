export interface IDocument {
  id: number;
  name: string;
  createdAt: string;
  fileRecognitionStatus: number;
  resource: string;
  createdBy: string;
  description: string;
  downloadUrl: string;
}