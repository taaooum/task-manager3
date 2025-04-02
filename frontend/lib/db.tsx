
interface Bucket {
    id: string;
    title: string;
    description: string;
}

interface Item {
    id: string;
    title: string;
    description: string;
    bucketId: string;
}