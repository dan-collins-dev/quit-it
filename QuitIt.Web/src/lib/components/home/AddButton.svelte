<script>
	import addIconSrc from "$lib/assets/add-circle-outline.svg";

	const { onOpen } = $props();
</script>

<button onclick={() => onOpen()}>
	<img src={addIconSrc} alt="" />
</button>

<style>
	img {
		width: 100%;
	}
	button {
		position: absolute;
		bottom: 7rem;
		margin: 0 auto;
		margin-top: auto;
		font-size: large;
		border: none;
		background-color: rgb(1, 82, 255);
		color: white;
		width: 50px;
		height: 50px;
		border-radius: 50%;
		filter: invert(1);
	}

	img {
		/* filter: invert(1); */
	}

	button:hover {
		background-color: #ff0000;
		cursor: pointer;
		filter: invert(0);
	}

	img:hover {
		filter: invert(1);
	}
</style>
