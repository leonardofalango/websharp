export interface CompleteNews
{
    id: string;
    title: string;
    thumbnail: string;
    content: string;
    city: string;
    state: string;
    country: string;
    newsDate: Date;
    topics: string[];
}