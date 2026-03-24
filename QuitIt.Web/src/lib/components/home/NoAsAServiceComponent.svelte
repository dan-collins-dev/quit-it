<script>
	import { onMount } from "svelte";

	let { ...reasonObject } = $state({});

	onMount(async () => {
		try {
			const res = await fetch("https://naas.isalman.dev/no");
			const data = await res.json();
			// console.log(data);
			reasonObject = data;
		} catch (error) {
			console.error(error);
		}
	});
</script>

<article>
	<h2>Reason to Not Smoke</h2>
	<p>{reasonObject.reason}</p>
</article>

<style>
	article {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
	}

	p,
	h2 {
		color: black;
	}
</style>
