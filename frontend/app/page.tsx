import Image from "next/image";
import Link
 from "next/link";
export default function Page() {
  return (
    <main>
      <h1>Overview!</h1>
      <Link href="/buckets">
        <button>Buckets</button>
      </Link>
    </main>
  );
}
